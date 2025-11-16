// Ensure we have a company to test with
if (!tp.CollectionVariables.Contains("CompanyId"))
{
    tp.SetVariable("CompanyId", 1); // Default to company ID 1
}
