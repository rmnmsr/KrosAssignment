tp.Test("Department should have ID", () => {
    dynamic department = tp.Response.GetBodyAsExpando();
    True(department.id > 0);
});

dynamic responseBody = tp.Response.GetBodyAsExpando();
tp.SetVariable("DepartmentId", responseBody.id);
