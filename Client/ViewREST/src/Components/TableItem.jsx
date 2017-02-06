import React, { Component } from "react";
import "../css/TableItem.sass";
const classNames = require('classnames');
const ModuleAJAX = require("../ModuleAJAX.js");

const deleteClasses = classNames({
    "glyphicon": true,
    "glyphicon-trash": true,
    "delete_icon": true
});

export default class TableItem extends Component {
    constructor(props) {
        super(props);
    }

    deleteHandler = () => {
        ModuleAJAX.delete(this.props.tableName, this.props.item.Id);
        this.props.onChangeTableData(ModuleAJAX.select(this.props.tableName));
    }

    render() {
        let item = this.props.item;
        
        return (            
            <tr>
                {/*создание строки*/}
                { Object.keys(item).map(key => <td key={key.toString()}>{item[key]}</td>) }
                
                {/*кнопка удаления записи*/}
                <td><span onClick={this.deleteHandler} className={deleteClasses}></span></td>
            </tr>
        );
    }
}