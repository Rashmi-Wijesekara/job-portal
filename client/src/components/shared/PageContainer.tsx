import React, { ReactNode } from "react";
import { Container } from "react-bootstrap";

type ComponentProps = {
	children: ReactNode;
};

const PageContainer = ({ children }: ComponentProps) => {
	return (
		<Container
			style={{ marginTop: "4.5rem", marginBottom: "2rem" }}
		>
			{children}
		</Container>
	);
};

export default PageContainer;
