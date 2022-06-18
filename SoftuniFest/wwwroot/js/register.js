
// Declarate application
// app can be used to access and debug the application

var app = new Vue({

    // HTML selector of the parent item in the application
    el: '#app',

    // use Vuetify component system
    vuetify: new Vuetify(),

    // application data
    data: {
        isLoading: false,
        // username
        user: "",
        // password stored in clear text
        password: "",
        // do show the login error dialog
        errDialog: false,
        // error message
        errText: null,
    },

    mounted()
    {

    },

    // application actions
    methods: {

        // Authenticate user
        login() {

            try
            {
                this.isLoading = true;
                axios.post(document.getElementById("loginUrl").value, { "userName": app.user, "password": app.password })
                    .then(function (response) {
                        window.location.href = document.getElementById("homeUrl").value;
                    })
                    .catch(function (err) {
                        app.errText = err.response.data;
                        app.errDialog = true;
                    })
                    .then(function () {
                        app.isLoading = false;
                    });
            }
            // Something went horrablly wrong!
            catch (err)
            {
                this.isLoading = false;
                this.errText = "Нещо се обърка!";
                this.errDialog = true;
            }
        }

    }
})