using System.Runtime.InteropServices;
using System.Text;

namespace AllScreenshots.Sdk.Tests.Integration;

/// <summary>
/// Generates HTML test reports.
/// </summary>
public static class TestReportGenerator
{
    /// <summary>
    /// Generates an HTML test report.
    /// </summary>
    /// <param name="results">Test results.</param>
    public static void GenerateReport(IEnumerable<TestResult> results)
    {
        var resultsList = results.ToList();
        var passed = resultsList.Count(r => r.Passed);
        var failed = resultsList.Count - passed;
        var totalTimeMs = resultsList.Sum(r => r.ExecutionTimeMs);

        var html = new StringBuilder();
        html.AppendLine("<!DOCTYPE html>");
        html.AppendLine("<html lang=\"en\">");
        html.AppendLine("<head>");
        html.AppendLine("  <meta charset=\"UTF-8\">");
        html.AppendLine("  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
        html.AppendLine("  <title>Allscreenshots SDK Integration Test Report</title>");
        html.AppendLine("  <style>");
        html.AppendLine(@"
    * { box-sizing: border-box; margin: 0; padding: 0; }
    body { font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif; line-height: 1.6; color: #333; background: #f5f5f5; }
    .container { max-width: 1200px; margin: 0 auto; padding: 20px; }
    header { background: #1a1a1a; color: white; padding: 30px 20px; margin-bottom: 30px; }
    header h1 { font-size: 24px; font-weight: 500; margin-bottom: 5px; }
    header .subtitle { color: #888; font-size: 14px; }
    .summary { display: grid; grid-template-columns: repeat(auto-fit, minmax(150px, 1fr)); gap: 15px; margin-bottom: 30px; }
    .summary-card { background: white; padding: 20px; border-radius: 8px; box-shadow: 0 1px 3px rgba(0,0,0,0.1); }
    .summary-card .label { font-size: 12px; color: #666; text-transform: uppercase; margin-bottom: 5px; }
    .summary-card .value { font-size: 28px; font-weight: 600; }
    .summary-card.passed .value { color: #22c55e; }
    .summary-card.failed .value { color: #ef4444; }
    .test-card { background: white; border-radius: 8px; box-shadow: 0 1px 3px rgba(0,0,0,0.1); margin-bottom: 15px; overflow: hidden; }
    .test-header { display: flex; align-items: center; justify-content: space-between; padding: 15px 20px; border-bottom: 1px solid #eee; }
    .test-header .test-id { font-weight: 600; color: #666; margin-right: 10px; }
    .test-header .test-name { flex: 1; font-weight: 500; }
    .badge { padding: 4px 12px; border-radius: 20px; font-size: 12px; font-weight: 500; }
    .badge.pass { background: #dcfce7; color: #166534; }
    .badge.fail { background: #fee2e2; color: #991b1b; }
    .test-details { padding: 15px 20px; font-size: 14px; }
    .test-details .row { display: flex; margin-bottom: 8px; }
    .test-details .label { color: #666; width: 100px; }
    .test-details .value { flex: 1; }
    .test-image { padding: 15px 20px; background: #fafafa; border-top: 1px solid #eee; }
    .test-image img { max-width: 100%; height: auto; border-radius: 4px; border: 1px solid #ddd; }
    .error-message { background: #fee2e2; color: #991b1b; padding: 10px 15px; border-radius: 4px; font-size: 13px; margin-top: 10px; }
    footer { text-align: center; padding: 30px 20px; color: #666; font-size: 13px; }
");
        html.AppendLine("  </style>");
        html.AppendLine("</head>");
        html.AppendLine("<body>");
        html.AppendLine("  <header>");
        html.AppendLine("    <div class=\"container\">");
        html.AppendLine("      <h1>Allscreenshots SDK Integration Test Report</h1>");
        html.AppendLine($"      <div class=\"subtitle\">.NET SDK v1.0.0 | {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</div>");
        html.AppendLine("    </div>");
        html.AppendLine("  </header>");
        html.AppendLine("  <div class=\"container\">");
        html.AppendLine("    <div class=\"summary\">");
        html.AppendLine($"      <div class=\"summary-card\"><div class=\"label\">Total tests</div><div class=\"value\">{resultsList.Count}</div></div>");
        html.AppendLine($"      <div class=\"summary-card passed\"><div class=\"label\">Passed</div><div class=\"value\">{passed}</div></div>");
        html.AppendLine($"      <div class=\"summary-card failed\"><div class=\"label\">Failed</div><div class=\"value\">{failed}</div></div>");
        html.AppendLine($"      <div class=\"summary-card\"><div class=\"label\">Total time</div><div class=\"value\">{totalTimeMs / 1000.0:F1}s</div></div>");
        html.AppendLine("    </div>");

        foreach (var result in resultsList.OrderBy(r => r.TestId))
        {
            html.AppendLine("    <div class=\"test-card\">");
            html.AppendLine("      <div class=\"test-header\">");
            html.AppendLine($"        <span class=\"test-id\">{result.TestId}</span>");
            html.AppendLine($"        <span class=\"test-name\">{result.TestName}</span>");
            html.AppendLine($"        <span class=\"badge {(result.Passed ? "pass" : "fail")}\">{(result.Passed ? "PASS" : "FAIL")}</span>");
            html.AppendLine("      </div>");
            html.AppendLine("      <div class=\"test-details\">");
            html.AppendLine($"        <div class=\"row\"><span class=\"label\">URL</span><span class=\"value\">{result.Url}</span></div>");
            html.AppendLine($"        <div class=\"row\"><span class=\"label\">Device</span><span class=\"value\">{result.Device}</span></div>");
            html.AppendLine($"        <div class=\"row\"><span class=\"label\">Full page</span><span class=\"value\">{result.FullPage}</span></div>");
            html.AppendLine($"        <div class=\"row\"><span class=\"label\">Time</span><span class=\"value\">{result.ExecutionTimeMs}ms</span></div>");

            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                html.AppendLine($"        <div class=\"error-message\">{result.ErrorMessage}</div>");
            }

            html.AppendLine("      </div>");

            if (result.ImageBytes != null && result.ImageBytes.Length > 0)
            {
                var base64 = Convert.ToBase64String(result.ImageBytes);
                html.AppendLine("      <div class=\"test-image\">");
                html.AppendLine($"        <img src=\"data:image/png;base64,{base64}\" alt=\"Screenshot\" />");
                html.AppendLine("      </div>");
            }

            html.AppendLine("    </div>");
        }

        html.AppendLine("  </div>");
        html.AppendLine("  <footer>");
        html.AppendLine($"    <p>Environment: {RuntimeInformation.OSDescription} | .NET {Environment.Version}</p>");
        html.AppendLine("  </footer>");
        html.AppendLine("</body>");
        html.AppendLine("</html>");

        var outputPath = Path.Combine(GetOutputDirectory(), "test-report.html");
        File.WriteAllText(outputPath, html.ToString());

        Console.WriteLine($"Test report generated: {outputPath}");
    }

    private static string GetOutputDirectory()
    {
        // Try to find the project root
        var currentDir = Directory.GetCurrentDirectory();

        // Walk up to find the test project directory
        while (!string.IsNullOrEmpty(currentDir))
        {
            if (File.Exists(Path.Combine(currentDir, "AllScreenshots.Sdk.Tests.Integration.csproj")))
            {
                return currentDir;
            }

            currentDir = Directory.GetParent(currentDir)?.FullName;
        }

        // Fall back to current directory
        return Directory.GetCurrentDirectory();
    }
}
