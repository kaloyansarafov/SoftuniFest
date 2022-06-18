
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
        
        // do show the login error dialog
        errDialog: false,
        // error message
        errText: null,
    },

    // application actions
    methods: {

        

    }
})