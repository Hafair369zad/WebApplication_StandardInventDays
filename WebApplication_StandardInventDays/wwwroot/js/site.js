


//$(document).ready(function () {
//    // Aktifkan atau nonaktifkan sidebar saat tombol hamburger diklik
//    $("#sidebarToggle").click(function () {
//        $(".sidebar").toggleClass("active");
//        $(".content").toggleClass("active");
//    });
//});
var hamburger = document.querySelector(".hamburger");
hamburger.addEventListener("click", function () {
    document.querySelector("body").classList.toggle("active");
})

$(document).ready(function () {
    // Get the current URL path
    var currentPath = window.location.pathname;

    // Remove the trailing slash (if any)
    currentPath = currentPath.replace(/\/$/, '');

    // Find the corresponding menu item and add the "active" class
    $('#nav_accordion li').each(function () {
        var menuItem = $(this).find('a');
        var menuItemUrl = menuItem.attr('href');

        // Check if the current path matches the menu item URL
        if (currentPath === menuItemUrl) {
            menuItem.addClass('active');
        }
    });
});


// sidebar menu collapse
document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('.sidebar .nav-link').forEach(function (element) {

        element.addEventListener('click', function (e) {

            let nextEl = element.nextElementSibling;
            let parentEl = element.parentElement;

            if (nextEl) {
                e.preventDefault();
                let mycollapse = new bootstrap.Collapse(nextEl);

                if (nextEl.classList.contains('show')) {
                    mycollapse.hide();
                } else {
                    mycollapse.show();
                    // find other submenus with class=show
                    var opened_submenu = parentEl.parentElement.querySelector('.submenu.show');
                    // if it exists, then close all of them
                    if (opened_submenu) {
                        new bootstrap.Collapse(opened_submenu);
                    }
                }
            }
        }); // addEventListener
    }) // forEach
});
// DOMContentLoaded  end
// End Sidebar menu collapse



// Form Ouput Hasil
$("#processButton").click(function (e) {
    e.preventDefault(); 
    var hasil = "120"; 
    $("#hasil").val(hasil);
});

$("#clearButton").click(function (e) {
    e.preventDefault(); 
    $("form")[0].reset(); 
    $("#hasil").val(""); 
});

// End Output Hasil


// Grafik Chart 1
var dataBar = {
    labels: ["Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember"],
    datasets: [
        {
            label: "Data 1",
            backgroundColor: "#4EA652", // Warna hijau dengan tingkat transparansi
            data: [30, 25, 5, 10, 15, 18, 22, 14, 25, 25, 20, 28]
        },
        {
            label: "Data 2",
            backgroundColor: "#A50808", // Warna merah dengan tingkat transparansi
            data: [50, 25, 55, 30, 10, 20, 15, 25, 28, 22, 18, 28]
        },
        {
            label: "Data 3",
            backgroundColor: "#004891", // Warna biru dengan tingkat transparansi
            data: [30, 35, 45, 25, 18, 25, 20, 28, 15, 22, 28, 12]
        },
        {
            label: "Data 4",
            backgroundColor: "#FFD600", // Warna biru dengan tingkat transparansi
            data: [25, 30, 48, 30, 18, 25, 20, 27, 15, 22, 28, 12]
        },
        {
            label: "Data 5",
            type: "line",
            borderColor: "rgba(0, 0, 0, 1)", // Warna garis hitam
            borderWidth: 1, // Lebar garis
            data: [30, 55, 45, 60, 25, 10, 5, 26, 28, 30, 20, 39]
        }
    ]
};

// Opsi konfigurasi grafik
var options = {
    scales: {
        x: {
            beginAtZero: true
        },
        y: {
            beginAtZero: true
        }
    }
};

// Mengambil elemen canvas dan membuat grafik tipe bar
var ctxBar = document.getElementById("grafik1").getContext("2d");
var myChartBar = new Chart(ctxBar, {
    type: "bar",
    data: dataBar,
    options: options
});
// End Grafik Chart 1


// Grafik Chart 2
// Data untuk grafik tipe donat (grafik 2)
var dataDonut = {
    labels: ["Label 1", "Label 2", "Label 3", "Label 4"],
    datasets: [
        {
            data: [30, 40, 20, 15],
            backgroundColor: ["#4EA652", "#A50808", "#004891", "#FFD600"]
        }
    ]
};

// function options chart 
var optionsDonut = {
    responsive: true,
    maintainAspectRatio: false,
    plugins: {
        legend: {
            position: 'bottom' // Menempatkan legenda di bawah grafik
        }
    }
};

// Mengambil elemen canvas dan membuat grafik tipe donat (grafik 2)
var ctxDonut = document.getElementById("grafik2").getContext("2d");
var myChartDonut = new Chart(ctxDonut, {
    type: "doughnut",
    data: dataDonut,
    options: optionsDonut
});
// End Grafik Chart 2


// Dropwon Chart
$(document).ready(function () {
    // Ketika item dropdown dipilih
    $(".dropdown-item").click(function () {
        // Hapus kelas active dari semua item dropdown
        $(".dropdown-item").removeClass("active");

        // Tambahkan kelas active ke item yang dipilih
        $(this).addClass("active");

        // Ambil nilai (value) dari item yang dipilih
        var selectedValue = $(this).attr("value");

        // Ganti teks pada tombol dropdown dengan nilai yang dipilih
        $(".btn-typeChart").text(selectedValue);

        // Anda juga dapat melakukan tindakan lain sesuai kebutuhan di sini

        // Contoh: Cetak nilai yang dipilih ke konsol
        console.log("Anda memilih: " + selectedValue);
    });
});
// End Dropdown Chart


// Progress Bar Chart Atas 
// Mengambil elemen-elemen progress bar berdasarkan class mereka
var progressBarIMP = document.querySelector(".progress-barIMP");
var progressBarLOC = document.querySelector(".progress-barLOC");
var progressBarALL = document.querySelector(".progress-barALL");

// Mengatur nilai progress bar untuk masing-masing elemen
var progressValueIMP = 32; // Nilai untuk progress bar IMP
var progressValueLOC = 65; // Nilai untuk progress bar LOC
var progressValueALL = 80; // Nilai untuk progress bar ALL

// Mengatur nilai atribut aria-valuenow dan lebar progress bar
progressBarIMP.style.width = progressValueIMP + "%";
progressBarIMP.setAttribute("aria-valuenow", progressValueIMP);

progressBarLOC.style.width = progressValueLOC + "%";
progressBarLOC.setAttribute("aria-valuenow", progressValueLOC);

progressBarALL.style.width = progressValueALL + "%";
progressBarALL.setAttribute("aria-valuenow", progressValueALL);

// End Progress Bar Chart Atas


// Donut Chart Bawah
const progressCircles = document.querySelectorAll('.progress-circle');

// Contoh data dari sumber data (bisa diganti dengan data dari database/API)
const dataFromDatabase = [
    { value: 40, color: '#3498db' },
    { value: 65, color: '#e74c3c' },
    { value: 20, color: '#27ae60' },
    { value: 75, color: '#27ae60' },
];

function updateProgress() {
    dataFromDatabase.forEach((data, index) => {
        const circle = progressCircles[index];
        const currentValue = parseInt(circle.querySelector('.progress-label').textContent);
        const targetValue = data.value;

        if (currentValue < targetValue) {
            circle.querySelector('.progress-label').textContent = `${currentValue + 1}%`;
            circle.style.transform = `rotate(${(currentValue + 1) * 3.6}deg)`;
        }
    });
}

// Memulai animasi otomatis saat halaman dimuat
setInterval(updateProgress, 50);

// End Donut Chart Bawah



$(document).ready(function () {
    $('.dropdown-toggle').dropdown(); // Menginisialisasi perilaku dropdown pada elemen dengan class "dropdown-toggle"
});




// Delete SID Popup
//$(document).ready(function () {
//    // Tambahkan event click pada setiap tombol delete
//    $("[id^='deleteBtn-']").click(function () {
//        var idSid = this.id.split('-')[1]; // Ambil ID SID dari tombol delete
//        $.ajax({
//            url: '/DeleteSID?id=' + idSid, // Ganti dengan URL yang benar
//            type: 'GET',
//            success: function (data) {
//                // Isi konten popup dengan data yang diambil dari server
//                $("#deleteSIDPopup").html(data);
//                // Tampilkan popup
//                $("#deleteSIDPopup").show();
//            }
//        });
//    });

//    // Tambahkan event click pada tombol "Delete" di dalam popup
//    $("#deleteSIDPopup").on("click", "input[type=submit]", function () {
//        // Lakukan operasi delete di sini, jika diperlukan
//        // Setelah selesai, sembunyikan popup
//        $("#deleteSIDPopup").hide();
//    });
//});
// End Delete SID Popup 


 // Dark Mode 
// Mengambil elemen tombol switch
//const darkModeToggle = document.getElementById("dark-mode-toggle");

//// Memeriksa apakah mode gelap sudah diaktifkan sebelumnya
//if (localStorage.getItem("dark-mode") === "enabled") {
//    document.body.classList.add("dark-mode");
//    darkModeToggle.checked = true;
//}

//// Fungsi untuk mengaktifkan atau menonaktifkan mode gelap
//function toggleDarkMode() {
//    if (document.body.classList.contains("dark-mode")) {
//        document.body.classList.remove("dark-mode");
//        localStorage.setItem("dark-mode", "disabled");
//    } else {
//        document.body.classList.add("dark-mode");
//        localStorage.setItem("dark-mode", "enabled");
//    }
//}

//// Mendengarkan perubahan pada tombol switch
//darkModeToggle.addEventListener("change", toggleDarkMode);



