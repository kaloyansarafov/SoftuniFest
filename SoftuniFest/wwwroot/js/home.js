
// Declarate application
// app can be used to access and debug the application

var app = new Vue({

    // HTML selector of the parent item in the application
    el: '#app',

    // use Vuetify component system
    vuetify: new Vuetify(),

    // application data
    data: {
        drawer: null,

        newPost:null,

        // do show the login error dialog
        errDialog: false,
        // error message
        errText: null,
    },

    // application actions
    methods: {

        post() {

            try {
                this.isLoading = true;
                axios.post("../api/posts", { postContent: app.newPost })
                    .then(function (response) {
                        window.location.href = window.location.href;
                    })
                    .catch(function (err) {
                        window.location.href = window.location.href;
                    })
                    .then(function () {
                        app.isLoading = false;
                    });
            }
            // Something went horrablly wrong!
            catch (err) {
                this.isLoading = false;
                this.errText = "Нещо се обърка!";
                this.errDialog = true;
            }
        }

    }
})