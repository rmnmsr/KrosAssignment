tp.Test("Company was created with correct data", () => {
    dynamic company = tp.Responses["CreateCompany"].GetBodyAsExpando();
    True(company.id > 0);
    Equal("Test Company Flow", company.name);
    Equal("TCF001", company.code);
});

tp.Test("Company can be retrieved by ID", () => {
    dynamic company = tp.Responses["GetCompanyById"].GetBodyAsExpando();
    Equal("Test Company Flow", company.name);
});

tp.Test("Company was updated correctly", () => {
    dynamic company = tp.Responses["UpdateCompany"].GetBodyAsExpando();
    Equal("Updated Company Flow", company.name);
    Equal("TCF001-UPD", company.code);
});

tp.Test("Company was deleted", () => {
    Equal(204, tp.Responses["DeleteCompany"].StatusCode());
});
