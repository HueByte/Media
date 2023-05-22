/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    extend: {
      colors: {
        elementBackgrounds: "#EAF0CE",
        accent: "#EC0B43",
        backgroundColorLight: "#011a2e",
        backgroundColor: "#001220",
        altBackgroundColor: "#000c14",
        altBackgroundColorLight: "#051929",
        element: "#000c14",
        accent: "#00fa9a",
        accent2: "#c62368",
        accent3: "#fa7268",
        accent4: "#da3f67",
      },
    },
  },
  plugins: [
    "tailwindcss",
    "autoprefixer",
    "postcss-import",
    "tailwindcss/nesting",
  ],
};
