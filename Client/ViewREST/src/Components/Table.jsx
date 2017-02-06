import React, { Component } from "react";
import TableItem from "./TableItem.jsx";
import AddForm from "./AddForm.jsx";
const classNames = require('classnames');

import "../css/Table.sass";

const tableClasses = classNames({
    "table": true,
    "table-bordered": true,
    "table-hover": true,
    "text-center": true
});

const additionClasses = classNames({
    "glyphicon": true,
    "glyphicon-plus": true,
    "additionButton": true
});

export default class Table extends Component {
    constructor(props) {
        super(props);

        this.state = {
            isAddition: false
        };
    }

    additionHandler = () => {
        this.setState({ isAddition: !this.state.isAddition });
    }

    render() {
        let rows = this.props.tableData;

        if (rows != null)
        return (
            <div className="main_table">
                <table className={tableClasses}>
                    <tbody>                        
                        <tr className="active">
                            {/*названия столбцов*/}
                            { Object.keys(rows[0]).map(key =>
                            <th
                                key={key.toString()}
                                className="text-center">
                                {key}
                            </th>) }
                            {/*кнопка добавления записи*/}
                            <th colSpan="2" className="text-center">
                                <span
                                    className={additionClasses}
                                    onClick={this.additionHandler}>
                                </span>
                            </th>
                        </tr>
                        {
                            rows.map(item =>
                                <TableItem
                                    key={item.Id}
                                    item={item}
                                    tableName={this.props.tableName}
                                    onChangeTableData={this.props.onChangeTableData}
                                />
                            )
                        }
                    </tbody>
                </table>
                {
                    this.state.isAddition ?
                        <AddForm
                            fields={Object.keys(this.props.tableData[0])}
                            onAdditionHandler={this.additionHandler}
                            tableName={this.props.tableName}
                            onChangeTableData={this.props.onChangeTableData}                            
                        />
                        :
                        null
                }
            </div>
        );

        return null;
    }
}