# AllScreenshots.Sdk.Api.ComposeApi

All URIs are relative to *https://api.allscreenshots.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**Compose**](ComposeApi.md#compose) | **POST** /v1/screenshots/compose |  |
| [**GetComposeJobStatus**](ComposeApi.md#getcomposejobstatus) | **GET** /v1/screenshots/compose/jobs/{jobId} |  |
| [**GetLayoutPreview**](ComposeApi.md#getlayoutpreview) | **GET** /v1/screenshots/compose/preview |  |
| [**ListComposeJobs**](ComposeApi.md#listcomposejobs) | **GET** /v1/screenshots/compose/jobs |  |

<a id="compose"></a>
# **Compose**
> FileParameter Compose (ComposeRequest composeRequest)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AllScreenshots.Sdk.Api;
using AllScreenshots.Sdk.Client;
using AllScreenshots.Sdk.Model;

namespace Example
{
    public class ComposeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.allscreenshots.com";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ComposeApi(httpClient, config, httpClientHandler);
            var composeRequest = new ComposeRequest(); // ComposeRequest | 

            try
            {
                FileParameter result = apiInstance.Compose(composeRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComposeApi.Compose: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ComposeWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<FileParameter> response = apiInstance.ComposeWithHttpInfo(composeRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ComposeApi.ComposeWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **composeRequest** | [**ComposeRequest**](ComposeRequest.md) |  |  |

### Return type

[**FileParameter**](FileParameter.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/octet-stream, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Composed image |  -  |
| **202** | Composition accepted |  -  |
| **400** | API error |  -  |
| **401** | API error |  -  |
| **403** | API error |  -  |
| **404** | API error |  -  |
| **409** | API error |  -  |
| **422** | API error |  -  |
| **429** | API error |  -  |
| **500** | API error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getcomposejobstatus"></a>
# **GetComposeJobStatus**
> ComposeJobStatusResponse GetComposeJobStatus (string jobId)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AllScreenshots.Sdk.Api;
using AllScreenshots.Sdk.Client;
using AllScreenshots.Sdk.Model;

namespace Example
{
    public class GetComposeJobStatusExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.allscreenshots.com";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ComposeApi(httpClient, config, httpClientHandler);
            var jobId = "jobId_example";  // string | 

            try
            {
                ComposeJobStatusResponse result = apiInstance.GetComposeJobStatus(jobId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComposeApi.GetComposeJobStatus: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetComposeJobStatusWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ComposeJobStatusResponse> response = apiInstance.GetComposeJobStatusWithHttpInfo(jobId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ComposeApi.GetComposeJobStatusWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobId** | **string** |  |  |

### Return type

[**ComposeJobStatusResponse**](ComposeJobStatusResponse.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | API error |  -  |
| **401** | API error |  -  |
| **403** | API error |  -  |
| **404** | API error |  -  |
| **409** | API error |  -  |
| **422** | API error |  -  |
| **429** | API error |  -  |
| **500** | API error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getlayoutpreview"></a>
# **GetLayoutPreview**
> LayoutPreviewResponse GetLayoutPreview (string layout, int imageCount, int? canvasWidth = null, int? canvasHeight = null, List<double>? aspectRatios = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AllScreenshots.Sdk.Api;
using AllScreenshots.Sdk.Client;
using AllScreenshots.Sdk.Model;

namespace Example
{
    public class GetLayoutPreviewExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.allscreenshots.com";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ComposeApi(httpClient, config, httpClientHandler);
            var layout = "layout_example";  // string | 
            var imageCount = 56;  // int | 
            var canvasWidth = 1200;  // int? |  (optional)  (default to 1200)
            var canvasHeight = 800;  // int? |  (optional)  (default to 800)
            var aspectRatios = new List<double>?(); // List<double>? |  (optional) 

            try
            {
                LayoutPreviewResponse result = apiInstance.GetLayoutPreview(layout, imageCount, canvasWidth, canvasHeight, aspectRatios);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComposeApi.GetLayoutPreview: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetLayoutPreviewWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LayoutPreviewResponse> response = apiInstance.GetLayoutPreviewWithHttpInfo(layout, imageCount, canvasWidth, canvasHeight, aspectRatios);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ComposeApi.GetLayoutPreviewWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **layout** | **string** |  |  |
| **imageCount** | **int** |  |  |
| **canvasWidth** | **int?** |  | [optional] [default to 1200] |
| **canvasHeight** | **int?** |  | [optional] [default to 800] |
| **aspectRatios** | [**List&lt;double&gt;?**](double.md) |  | [optional]  |

### Return type

[**LayoutPreviewResponse**](LayoutPreviewResponse.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | API error |  -  |
| **401** | API error |  -  |
| **403** | API error |  -  |
| **404** | API error |  -  |
| **409** | API error |  -  |
| **422** | API error |  -  |
| **429** | API error |  -  |
| **500** | API error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listcomposejobs"></a>
# **ListComposeJobs**
> List&lt;ComposeJobSummaryResponse&gt; ListComposeJobs ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AllScreenshots.Sdk.Api;
using AllScreenshots.Sdk.Client;
using AllScreenshots.Sdk.Model;

namespace Example
{
    public class ListComposeJobsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.allscreenshots.com";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ComposeApi(httpClient, config, httpClientHandler);

            try
            {
                List<ComposeJobSummaryResponse> result = apiInstance.ListComposeJobs();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComposeApi.ListComposeJobs: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListComposeJobsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<ComposeJobSummaryResponse>> response = apiInstance.ListComposeJobsWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ComposeApi.ListComposeJobsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;ComposeJobSummaryResponse&gt;**](ComposeJobSummaryResponse.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | API error |  -  |
| **401** | API error |  -  |
| **403** | API error |  -  |
| **404** | API error |  -  |
| **409** | API error |  -  |
| **422** | API error |  -  |
| **429** | API error |  -  |
| **500** | API error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

