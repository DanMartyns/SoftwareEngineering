import React, {Component} from 'react';
import './DisplayResultID.css'
import { Info } from 'grommet-icons';

class DisplayResultID extends Component {

    constructor(props){
        super(props);
    }

    render() {
    return (
        <div className="result">
            <Info color='plain' size='large' /> 
            <h2>{this.props.title}</h2>
            <p>{this.props.result}</p>
        </div>
    );
    }
    }

export default DisplayResultID;