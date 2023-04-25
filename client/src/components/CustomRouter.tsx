import React, { FC, PropsWithChildren } from "react";
import { unstable_HistoryRouter as HistoryRouter } from "react-router-dom";
import { createBrowserHistory } from "history";

const history = createBrowserHistory({ window });

const CustomRouter: FC<PropsWithChildren> = ({
	children,
	...props
}) => {
	return (
		<HistoryRouter history={history} {...props}>
			{children}
		</HistoryRouter>
	);
};

// eslint-disable-next-line react-refresh/only-export-components
export const rootNavigate = (to: string) => {
	history.push(to);
};

export default CustomRouter;
