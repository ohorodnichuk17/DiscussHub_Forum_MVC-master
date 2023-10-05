$(document).ready(function () {
    $('#avatar').on('change', function (e) {
        var file = e.target.files[0];
        var reader = new FileReader();

        reader.onloadend = function () {
            $('#avatar-preview').attr('src', reader.result);
        };

        if (file) {
            reader.readAsDataURL(file);
        }
    });

    $('#update-avatar-btn').click(function () {
        showToast('Success!', 'Avatar updated successfully.', 'success');
    });

    function showToast(title, message, type) {
        //Має бути відображення спливаючого повідомлення 
    }
});