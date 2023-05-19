/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    extend: {},
  },
  plugins: [
    "tailwindcss",
    "autoprefixer",
    "postcss-import",
    "tailwindcss/nesting",
  ],
};
