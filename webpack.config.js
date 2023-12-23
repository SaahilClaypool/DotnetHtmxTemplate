const path = require('path');
module.exports = {
    mode: 'production',
    entry: {
        main: './Views/app.js', // Path to your main JavaScript file
    },
    output: {
        filename: 'bundle.js', // Output JavaScript file
        path: path.resolve(__dirname, 'wwwroot/dist'),
    },
    module: {
        rules: [
            {
                test: /Views.*\.js$/,
                use: 'babel-loader', // You can add babel-loader for transpiling ES6+ syntax if needed
                exclude: /node_modules/,
            }
        ],
    },
    plugins: [
    ],
};