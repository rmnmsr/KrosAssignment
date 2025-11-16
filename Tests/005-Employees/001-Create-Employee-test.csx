tp.Test("Employee should have ID", () => {
    dynamic employee = tp.Response.GetBodyAsExpando();
    True(employee.id > 0);
});

tp.Test("Employee email should match", () => {
    dynamic employee = tp.Response.GetBodyAsExpando();
    Equal("john.doe@test.com", employee.email);
});

tp.Test("Employee full name should be correct", () => {
    dynamic employee = tp.Response.GetBodyAsExpando();
    Equal("Ján Novák", employee.fullName);
});

tp.Test("Employee title should be correct", () => {
    dynamic employee = tp.Response.GetBodyAsExpando();
    Equal("Ing.", employee.title);
});

dynamic responseBody = tp.Response.GetBodyAsExpando();
tp.SetVariable("EmployeeId", responseBody.id);
