import React from "react";
import {
	Navbar as Bn,
	Container,
	Nav,
	Button
} from "react-bootstrap";
import LogoImage from "../../assets/logo.png";
import UserImage from "../../assets/user.svg";

const Navbar = () => {
	const loginStatus = false
	const register = true

	return (
		<>
			<Bn
				bg="black"
				variant="dark"
				className="p-0 fixed-top"
			>
				<Container className="mx-3">
					<Bn.Brand href="#">
						<img
							alt=""
							src={LogoImage}
							width="50"
							height="50"
						/>
					</Bn.Brand>
				</Container>
				<Container className="justify-content-end mx-3">
					<Nav className="align-items-center">
						<Nav.Link href="#" className="mx-3">
							Jobs
						</Nav.Link>
						<Nav.Link href="#" className="mx-3">
							Applications
						</Nav.Link>
						{loginStatus && (
							<Nav.Link>
								<img
									src={UserImage}
									alt=""
									width="40"
									height="40"
								/>
							</Nav.Link>
						)}

						{!loginStatus && register && (
							<Nav.Link>
								<Button>Login</Button>
							</Nav.Link>
						)}

						{!loginStatus && !register && (
							<Nav.Link>
								<Button>Register</Button>
							</Nav.Link>
						)}
					</Nav>
				</Container>
			</Bn>
		</>
	);
};

export default Navbar;
