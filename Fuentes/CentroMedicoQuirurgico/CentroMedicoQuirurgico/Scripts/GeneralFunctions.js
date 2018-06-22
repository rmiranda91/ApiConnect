function filterTable(posColFilter) {
    // Declare variables
    var input, filter, table, tr, td, i;
    input = document.getElementById("txtFiltro");
    filter = input.value.toUpperCase();
    table = document.getElementById("tblData");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[posColFilter];
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function loadRole(id) {
    window.location.href = "/Admin/RoleApplication/" + id;
}

/*
$(document).ready(function () {
    //Dropdownlist Selectedchange event
    $("#Item2_idRole").change(function () {
        //$("#tblApplications").empty();
        var id = $("#Item2_idRole").val();
        window.location.href = "/Admin/RoleApplication/" + id;
    })
});
*/