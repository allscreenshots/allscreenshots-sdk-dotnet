# AllScreenshots.Sdk.Model.ScreenshotRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Actions** | [**List&lt;PageAction&gt;**](PageAction.md) |  | [optional] 
**BlockAds** | **bool** |  | [optional] [default to true]
**BlockCookieBanners** | **bool** |  | [optional] [default to true]
**BlockLevel** | **string** |  | [optional] [default to "none"]
**BlockPopups** | **bool** |  | [optional] [default to true]
**CustomCss** | **string** |  | [optional] 
**DarkMode** | **bool** |  | [optional] [default to false]
**Delay** | **int** |  | [optional] [default to 0]
**Device** | **string** |  | [optional] 
**Format** | **string** |  | [optional] [default to "png"]
**FreezeFixed** | **bool** |  | [optional] [default to true]
**FullPage** | **bool** |  | [optional] [default to false]
**FullPageMode** | **string** |  | [optional] [default to "stitch"]
**HideSelectors** | **List&lt;string&gt;** |  | [optional] 
**MaxHeight** | **int?** |  | [optional] 
**MaxSections** | **int** |  | [optional] [default to 50]
**Outputs** | [**List&lt;OutputSpec&gt;**](OutputSpec.md) |  | [optional] 
**Quality** | **int** |  | [optional] [default to 80]
**ResponseType** | **string** |  | [optional] [default to ResponseTypeEnum.BINARY]
**ScrollInterval** | **int** |  | [optional] [default to 150]
**Selector** | **string** |  | [optional] 
**Session** | [**BrowserSessionRequest**](BrowserSessionRequest.md) |  | [optional] 
**StealthMode** | **bool** |  | [optional] [default to false]
**Timeout** | **int** |  | [optional] [default to 30000]
**Url** | **string** |  | 
**Viewport** | [**ViewportConfig**](ViewportConfig.md) |  | [optional] 
**WaitFor** | **string** |  | [optional] 
**WaitUntil** | **string** |  | [optional] [default to "domcontentloaded"]
**WebhookSecret** | **string** |  | [optional] 
**WebhookUrl** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

