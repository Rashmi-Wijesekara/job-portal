import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "bootstrap/dist/css/bootstrap.min.css";
import CustomRouter from "./components/CustomRouter";

ReactDOM.createRoot(
	document.getElementById("root") as HTMLElement
).render(
	<CustomRouter>
		<App />
	</CustomRouter>
);
