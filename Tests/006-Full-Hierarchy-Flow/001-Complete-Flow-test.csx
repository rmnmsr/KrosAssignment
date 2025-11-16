tp.Test("Company for divisions was created", () => {
    dynamic company = tp.Responses["CreateCompanyForDivisions"].GetBodyAsExpando();
    True(company.id > 0);
});

tp.Test("Division was created with correct data", () => {
    dynamic division = tp.Responses["CreateDivision"].GetBodyAsExpando();
    True(division.id > 0);
    Equal("Test Division Flow", division.name);
    Equal("TDF001", division.code);
});

tp.Test("Division can be retrieved", () => {
    dynamic division = tp.Responses["GetDivisionById"].GetBodyAsExpando();
    Equal("Test Division Flow", division.name);
});

tp.Test("Department was created", () => {
    dynamic department = tp.Responses["CreateDepartment"].GetBodyAsExpando();
    True(department.id > 0);
    Equal("Test Department Flow", department.name);
});

tp.Test("Project was created", () => {
    dynamic project = tp.Responses["CreateProject"].GetBodyAsExpando();
    True(project.id > 0);
    Equal("Test Project Flow", project.name);
});

tp.Test("Employee was created", () => {
    dynamic employee = tp.Responses["CreateEmployee"].GetBodyAsExpando();
    True(employee.id > 0);
    Equal("Jana Mrázová", employee.fullName);
    Equal("Mgr.", employee.title);
    Equal("+421 111 222 333", employee.phone);
});
