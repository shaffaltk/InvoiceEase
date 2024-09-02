$(document).ready(function () {
    $('#LicenseKeyInput').on('input', function () {
        var licenseKey = $(this).val();
        var licenseKeyInput = $(this);
        var validationMessage = $('#licenseKeyValidationMessage');

        if (licenseKey.length > 0) {
            $.ajax({
                url: '/CheckLicenseKey',  // Adjust the URL if necessary
                type: 'GET',
                data: { licenseKey: licenseKey },
                success: function (response) {
                    if (response.exists) {
                        validationMessage.text('License key already exists.');
                        validationMessage.css('color', 'red');
                        licenseKeyInput.css('border-color', 'red');
                    } else {
                        validationMessage.text('');
                        licenseKeyInput.css('border-color', '');
                    }
                },
                error: function () {
                    validationMessage.text('Error checking license key.');
                    validationMessage.css('color', 'red');
                    licenseKeyInput.css('border-color', 'red');
                }
            });
        } else {
            validationMessage.text('');
            licenseKeyInput.css('border-color', '');
        }
    });
});
