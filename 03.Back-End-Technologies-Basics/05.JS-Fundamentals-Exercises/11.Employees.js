function listEmployees(array){
    let employeeData={};
    array.forEach(employee => {
        let personalNumber=employee.length;
        employeeData[employee] = personalNumber;
    });
    for(let employee in employeeData){
        console.log(`Name: ${employee} -- Personal Number: ${employeeData[employee]}`);
    }
}
