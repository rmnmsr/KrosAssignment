tp.Test("Division should have ID", () => {
    dynamic division = tp.Response.GetBodyAsExpando();
    True(division.id > 0);
});

tp.Test("Division name should match", () => {
    dynamic division = tp.Response.GetBodyAsExpando();
    Equal("Test Division", division.name);
});

dynamic responseBody = tp.Response.GetBodyAsExpando();
tp.SetVariable("DivisionId", responseBody.id);
