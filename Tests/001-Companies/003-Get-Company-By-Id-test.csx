tp.Test("Company should have correct structure", () => {
    dynamic company = tp.Response.GetBodyAsExpando();
    NotNull(company.id);
    NotNull(company.name);
    NotNull(company.code);
});
