$(document).ready(function () {
    var avatarInput = document.getElementById('avatar');

    function showAvatarPreview() {
        var file = avatarInput.files[0];
        var reader = new FileReader();

        reader.onloadend = function () {
            $('#avatar-preview').attr('src', reader.result);
        };

        if (file) {
            reader.readAsDataURL(file);
        }
    }

    avatarInput.addEventListener('change', showAvatarPreview);

    $('#updateProfileButton').click(function () {
        var formData = new FormData();
        var avatarFile = avatarInput.files[0];
        formData.append('avatar', avatarFile);

        $.ajax({
            url: '/Settings/ProfileSettings',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                console.log('Аватар оновлено успішно.');
                showToast('success', 'Success!', 'Your profile updated successfully.');
                location.reload(); 
            },
            error: function (error) {
                console.error('Помилка при оновленні аватарки:', error);
                showToast('error', 'Error!', 'Failed to update your profile.');
            }
        });
    });

    function showToast(type, title, message) {
       
    }

    showAvatarPreview();
});
