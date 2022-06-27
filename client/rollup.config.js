import alias from '@rollup/plugin-alias';
import clear from 'rollup-plugin-clear';
import replace from 'rollup-plugin-replace';
import babel from '@rollup/plugin-babel';
import commonjs from '@rollup/plugin-commonjs';
import resolve from '@rollup/plugin-node-resolve';
import typescript from '@rollup/plugin-typescript';
import json from "@rollup/plugin-json"
import scss from 'rollup-plugin-scss';
import copy from 'rollup-plugin-copy';
import dev from 'rollup-plugin-dev';

export default {
  input: "src/index.tsx",
  output: {
    file: "dist/bundle.js",
    format: "cjs"
  },
  plugins: [
    alias({
      entries: [
        { find: 'react', replacement: 'preact/compat' },
        { find: 'react-dom', replacement: 'preact/compat' }
      ]
    }),
    clear({
      targets: ['dist'],
      watch: true,
    }),
    replace({
      'process.env.NODE_ENV': JSON.stringify("development"),
    }),
    babel({
      presets: ["@babel/preset-react", "@babel/preset-typescript"],
      babelHelpers: 'bundled',
      exclude: "node_modules/**",
    }),
    commonjs(),
    resolve({
      jsnext: true,
      main: true,
      browser: true,
    }),
    typescript(),
    json(),
    scss({
      output: 'dist/bundle.css',
    }),
    copy({
      targets: [
        { src: 'src/Project/public/index.html', dest: 'dist' },
      ]
    }),    
    dev('dist'),
  ],
}
