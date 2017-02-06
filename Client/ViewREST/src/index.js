import React from "react";
import { render } from "react-dom";
import Application from "./Components/Application.jsx";

const root = document.createElement("div");
document.body.appendChild(root);

render (<Application />, root);