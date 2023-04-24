import React from "react";
import Multiselect from "multiselect-react-dropdown";

const MultiSelect = () => {
	return (
		<Multiselect
			displayValue="key"
			onKeyPressFn={function noRefCheck() {
				console.log(first);
			}}
			onRemove={function noRefCheck(selectedItem) {
				console.log(selectedItem);
			}}
			onSearch={function noRefCheck(value) {
				console.log(value);
			}}
			onSelect={function noRefCheck(selectedItem) {
				console.log(selectedItem);
			}}
			options={[
				{
					cat: "Group 1",
					key: "Option 1",
				},
				{
					cat: "Group 1",
					key: "Option 2",
				},
				{
					cat: "Group 1",
					key: "Option 3",
				},
				{
					cat: "Group 2",
					key: "Option 4",
				},
				{
					cat: "Group 2",
					key: "Option 5",
				},
				{
					cat: "Group 2",
					key: "Option 6",
				},
				{
					cat: "Group 2",
					key: "Option 7",
				},
			]}
			className=""
			placeholder="Select all your skills"
		/>
	);
};

export default MultiSelect;
