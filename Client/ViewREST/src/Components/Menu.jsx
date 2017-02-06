import React, { Component } from "react";
import MenuItem from "./MenuItem.jsx";

export default class Menu extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="list-group">                
                {
                    this.props.tableNames.map(item =>
                        <MenuItem
                            key={item.key}
                            name={item.value}
                            onChangeTableName={this.props.onChangeTableName}
                            onChangeTableData={this.props.onChangeTableData}
                        />
                    )
                }
            </div>
        );
    }
}