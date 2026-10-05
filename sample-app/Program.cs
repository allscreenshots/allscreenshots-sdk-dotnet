using AllScreenshots.Sdk.Api;
using AllScreenshots.Sdk.Client;
using AllScreenshots.Sdk.Model;
using Newtonsoft.Json;
var config = new Configuration {BasePath=Environment.GetEnvironmentVariable("ALLSCREENSHOTS_BASE_URL")??"https://api.allscreenshots.com", Timeout=TimeSpan.FromSeconds(180)};
config.ApiKey["X-API-Key"]=Environment.GetEnvironmentVariable("ALLSCREENSHOTS_API_KEY")??throw new Exception("Set ALLSCREENSHOTS_API_KEY");
var screenshots=new ScreenshotApi(config);var jobs=new JobApi(config);var mode=args.FirstOrDefault()??"quota";
if(mode=="quota") {Console.WriteLine(JsonConvert.SerializeObject(new UsageApi(config).GetQuota()));return;}
var request=new ScreenshotRequest(url:Environment.GetEnvironmentVariable("ALLSCREENSHOTS_URL")??"https://example.com",responseType:ScreenshotRequest.ResponseTypeEnum.URL,format:"png");
var key=Environment.GetEnvironmentVariable("ALLSCREENSHOTS_IDEMPOTENCY_KEY")??Guid.NewGuid().ToString();
FileParameter file;
if(mode=="sync") {
 using var raw=screenshots.CaptureSync(request,key).Content;using var reader=new StreamReader(raw);
 var metadata=JsonConvert.DeserializeObject<ScreenshotJsonResponse>(await reader.ReadToEndAsync())??throw new Exception("Invalid capture response");
 var parts=new Uri(metadata.ResultUrl,UriKind.RelativeOrAbsolute).IsAbsoluteUri?new Uri(metadata.ResultUrl).AbsolutePath.Split('/'):metadata.ResultUrl.Split('/');
 file=screenshots.GetSyncCaptureResult(parts[^2]);
} else if(mode=="async") {
 var job=jobs.CreateAsyncJob(request,key);var deadline=DateTime.UtcNow.AddSeconds(180);
 while(true) {var status=jobs.GetJobStatus(job.Id);var state=status.Status.ToString();if(state=="COMPLETED")break;if(state=="FAILED"||state=="CANCELLED")throw new Exception("Capture failed");if(DateTime.UtcNow>deadline)throw new Exception("Polling timed out");await Task.Delay(2000);}
 file=jobs.GetJobResult(job.Id);
} else throw new Exception("Expected quota, sync, or async");
var output=Environment.GetEnvironmentVariable("ALLSCREENSHOTS_OUTPUT")??"capture.png";
using(file.Content) {using var dest=File.Create(output);await file.Content.CopyToAsync(dest);}
Console.WriteLine(JsonConvert.SerializeObject(new {output}));
