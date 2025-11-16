tp.Test("Company should have ID", () => {
    dynamic company = tp.Response.GetBodyAsExpando();
    True(company.id > 0);
});

tp.Test("Company name should match", () => {
    dynamic company = tp.Response.GetBodyAsExpando();
    Equal("Test Company", company.name);
});

tp.Test("Company code should match", () => {
    dynamic company = tp.Response.GetBodyAsExpando();
    Equal("TC001", company.code);
});

// Store company ID for other tests
dynamic responseBody = tp.Response.GetBodyAsExpando();
tp.SetVariable("CompanyId", responseBody.id);
