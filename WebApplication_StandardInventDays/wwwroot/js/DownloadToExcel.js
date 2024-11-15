﻿// Fungsi untuk menambah ukuran font
function increaseFontSize() {
    changeFontSize(2); // Mengatur penambahan 2px
}

// Fungsi untuk mengurangi ukuran font
function decreaseFontSize() {
    changeFontSize(-2); // Mengatur pengurangan 2px
}

// Fungsi umum untuk mengubah ukuran font pada elemen th dan td
function changeFontSize(changeAmount) {
    const tableCells = document.querySelectorAll('.ViewExcel td, .ViewExcel th');

    tableCells.forEach(cell => {
        let currentFontSize = parseFloat(window.getComputedStyle(cell).fontSize);
        let newFontSize = currentFontSize + changeAmount;

        // Batas ukuran font minimal (8px) dan maksimal (20px)
        if (newFontSize < 8) {
            newFontSize = 8;
        } else if (newFontSize > 20) {
            newFontSize = 20;
        }

        cell.style.fontSize = newFontSize + 'px';
    });
}

// Menambahkan event listener ke tombol plus dan minus
document.getElementById('increase-text-size').addEventListener('click', increaseFontSize);
document.getElementById('decrease-text-size').addEventListener('click', decreaseFontSize);






// POPUP 
// Function to open the popup
document.getElementById('open-popup').addEventListener('click', function () {
    document.getElementById('popup').style.display = 'block';
    document.getElementById('overlay').style.display = 'block'; // Menampilkan overlay
});

// Function to close the popup and hide the overlay
document.getElementById('close-popup').addEventListener('click', function () {
    document.getElementById('popup').style.display = 'none';
    document.getElementById('overlay').style.display = 'none'; // Menyembunyikan overlay
});

// Function to trigger download based on selected format
document.getElementById('download-button').addEventListener('click', function () {
    console.log('Download button clicked');
    const selectedFormat = document.getElementById('file-format').value;

    // Create form data
    const formData = new FormData();
    formData.append('fileFormat', selectedFormat);

    // Trigger the download action on the server
    fetch('DownloadToExcel?handler=Download', {
        method: 'POST',
        body: formData // Use form data here
    })
        .then(response => {
            console.log('Response Status:', response.status);
            if (!response.ok) {
                throw new Error(`Network response was not ok: ${response.statusText}`);
            }
            return response.blob();
        })
        .then(blob => {
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = `SID_Data_${new Date().toISOString().slice(0, 19).replace(/:/g, "")}.${selectedFormat}`;
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
            window.URL.revokeObjectURL(url);
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        })
        .finally(() => {
            // Close the popup and hide the overlay after download or error
            document.getElementById('popup').style.display = 'none';
            document.getElementById('overlay').style.display = 'none';
        });
});
