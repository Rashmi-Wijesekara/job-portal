import {
	Container,
	Form,
	Row,
	Col,
	Button
} from "react-bootstrap";
import MultiSelect from "./MultiSelect";

const RegisterForm = () => {
	return (
		<Container className="shadow-lg py-4 px-5 my-6 bg-body rounded-3">
			<div className="fs-4 fw-bold text-center mb-4">
				User Registration
			</div>
			<Form>
				<Form.Group className="mb-3">
					<Row>
						<Col>
							<Form.Label>First Name</Form.Label>
							<Form.Control
								type="text"
								placeholder="Enter first name"
							/>
						</Col>
						<Col>
							<Form.Label>Last Name</Form.Label>
							<Form.Control
								type="text"
								placeholder="Enter last name"
							/>
						</Col>
					</Row>
				</Form.Group>
				<Form.Group controlId="formFile" className="mb-3">
					<Form.Label>CV</Form.Label>
					<Form.Control type="file" />
				</Form.Group>
				<Form.Group controlId="formFile" className="mb-3">
					<Form.Label>Cover Letter</Form.Label>
					<Form.Control type="file" />
				</Form.Group>
				<Form.Group className="mb-3">
					<Row>
						<Col>
							<Form.Label>Location</Form.Label>
							<Form.Select aria-label="Default select example">
								<option value="1">One</option>
								<option value="2">Two</option>
								<option value="3">Three</option>
							</Form.Select>
						</Col>

						<Col>
							<Form.Label>Skills</Form.Label>
							<Form.Select aria-label="Default select example">
								<option value="1">One</option>
								<option value="2">Two</option>
								<option value="3">Three</option>
							</Form.Select>
						</Col>
					</Row>
				</Form.Group>
				<Form.Group
					className="mb-3"
					controlId="formBasicEmail"
				>
					<Row>
						<Col>
							<Form.Label>Email address</Form.Label>
							<Form.Control
								type="email"
								placeholder="Enter email"
							/>
						</Col>
						<Col>
							<Form.Label>Password</Form.Label>
							<Form.Control
								type="password"
								placeholder="Password"
							/>
						</Col>
					</Row>
				</Form.Group>
				<div className="mb-3">
					<MultiSelect />
				</div>
				<Button variant="primary" type="submit">
					Register
				</Button>
			</Form>
		</Container>
	);
};

export default RegisterForm;
