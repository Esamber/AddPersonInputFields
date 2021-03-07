$(() => {
    let count = 1;
    $("#add-row").on('click', function () {
        var html = `
        <div class="row justify-content-center mt-2">
            <div class="col-md-4">
                <input type="text" name="people[${count}].firstName" class="form-control" placeholder="First Name" />
            </div>
            <div class="col-md-4">
                <input type="text"  name="people[${count}].lastName" class="form-control" placeholder="Last Name" />
            </div>
            <div class="col-md-4">
                <input type="number" name="people[${count}].age" class="form-control" placeholder="Age" />
            </div>
        </div>
`
        $("#input-people").append(html);
        count++;
    });
});
