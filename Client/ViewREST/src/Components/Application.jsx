import React, { Component } from "react";
import Menu from "./Menu.jsx";
import Table from "./Table.jsx";

import "../css/Application.sass";
import "bootstrap/dist/css/bootstrap.css";

const tableNames = [
    { key: 1, value: "Authors" },
    { key: 2, value: "Books" },
    { key: 3, value: "Publishers" },
    { key: 4, value: "BooksAuthors" }
];

export default class Application extends Component {
    constructor(props) {
        super(props);

        this.state = {
            currentTableName: null,
            currentTableData: null
        };
    }

    changeTableName = (tableName) => {
        this.setState({
            currentTableName: tableName
        });
    }

    changeTableData = (tableData) =>{
        this.setState({
            currentTableData: tableData
        });
    }

    render() {        
        return (
            <div className="container">
                <div className="row">
                    <div className="col-md-3 col-md-offset-1">
                        <h3>Таблицы</h3>
                        <Menu
                            tableNames={tableNames}
                            onChangeTableName={this.changeTableName}
                            onChangeTableData={this.changeTableData}
                        />
                    </div>
                    <div className="col-md-7">
                        <h3>Данные таблицы {this.state.currentTableName}</h3>
                        <Table
                            tableName={this.state.currentTableName}
                            tableData={this.state.currentTableData}
                            onChangeTableData={this.changeTableData}
                        />
                    </div>
                </div>
            </div>
        );
    }
}