# DefectsApp
Demonstates a defect in Microsoft.AspNetCore.OData

Compile and run this application.
When a request is sent to "/defects?$apply=groupby((Severity,Impact))&$top=2" an error response is returned due to the defect https://github.com/OData/AspNetCoreOData/issues/979.

Note that if the version of Microsoft.AspNetCore.OData is changed to 8.0.4, there is no error.
