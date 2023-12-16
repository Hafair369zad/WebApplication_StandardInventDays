document.addEventListener("DOMContentLoaded", function () {
    var dropdown = document.getElementById("dropdownVMINon");
    dropdown.addEventListener("change", function () {
        updateTable(dropdown.value);
    });

    function updateTable(selectedValue) {
        var thElements = document.querySelectorAll(".body-header3M");
        thElements.forEach(function (th) {
            if (selectedValue === "NonVMI" && th.textContent.trim() === "Reserved") {
                th.textContent = "Purchase";
            } else if (selectedValue === "VMI" && th.textContent.trim() === "Purchase") {
                th.textContent = "Reserved";
            }
        });
    }
});