(function () {

    $(function () {
        $("#LoginButton").click(function (e) {
            e.preventDefault();
            abp.ui.setBusy(
                $("#LoginArea"),
                abp.ajax({
                    url: abp.appPath + "Account/Login",
                    type: "POST",
                    data: JSON.stringify({
                        tenancyName: $("#TenancyName").val(),
                        usernameOrEmailAddress: $("#EmailAddressInput").val(),
                        password: $("#PasswordInput").val(),
                        rememberMe: $("#RememberMeInput").is(":checked"),
                        returnUrlHash: $("#ReturnUrlHash").val()
                    }),
                    error: function (response) {
                        console.log(response);
                        var title = $(response.responseText).get(1);
                        abp.ajax.showError({ message: title.text });
                    }
                })
            );
        });

        $("a.social-login-link").click(function () {
            var $a = $(this);
            var $form = $a.closest("form");
            $form.find("input[name=provider]").val($a.attr("data-provider"));
            $form.submit();
        });

        $("#ReturnUrlHash").val(location.hash);

        $("#LoginForm input").focus(function () {
            $(this).parent("div").parent("li").addClass("active");
        });

        $("#LoginForm input").blur(function () {
            $(this).parent("div").parent("li").removeClass("active");
        });

        $("#LoginForm input:first-child").focus();
    });

})();