import React from "react";
import "./index.css";
import {Routes, Route} from 'react-router-dom';

import Navbar from "./components/navbar/Navbar";
import RegisterPage from "./pages/RegisterPage";
import LoginPage from './pages/LoginPage';

const App = () => {
	return (
		<>
			<Navbar />
			<Routes>
				<Route
					path="/register"
					exact
					element={<RegisterPage />}
				/>
				<Route
					path="/login"
					exact
					element={<LoginPage />}
				/>
			</Routes>
		</>
	);
};

export default App;
