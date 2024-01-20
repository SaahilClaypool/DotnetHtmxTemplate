/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "Scripts/**/*.{cs,cshtml,html}",
        "Controllers/**/*.{cs,cshtml,html}"
    ],
    theme: {
        extend: {},
    },
    plugins: [
        require("@tailwindcss/typography"),
        require("daisyui"),
    ],
}

