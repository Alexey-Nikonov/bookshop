import React, { Component } from "react";
const ModuleAJAX = require("../ModuleAJAX.js");

export default class MenuItem extends Component {
    constructor(props) {
        super(props);
    }

    changeTableHandler = () => {
        this.props.onChangeTableName(this.props.name);
        this.props.onChangeTableData(ModuleAJAX.select(this.props.name))
    }

    render() {
        return (            
            <button
                className="list-group-item"
                onClick={this.changeTableHandler}>
                {this.props.name}
            </button>            
        );
    }
}