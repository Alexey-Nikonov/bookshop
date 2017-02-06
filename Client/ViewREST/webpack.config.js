const path = require("path");

module.exports = {
    entry: path.join(__dirname, "src", "index.js"),
    output: {
        path: __dirname + "/public/build/",
        filename: "bundle.js"
    },
    module: {
        loaders: [
            { test: /\.(js|jsx)$/, exclude: /node_modules/, loader: "babel-loader" },            
            { test: /\.(sass|css)$/, loader: "style-loader!css-loader!autoprefixer-loader!sass-loader"},
            { test: /\.(woff|woff2|eot|ttf|svg)$/, loader: "url-loader" }
        ]
    }
}