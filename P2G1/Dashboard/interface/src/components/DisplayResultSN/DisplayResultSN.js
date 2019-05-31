import React, {Component} from 'react';
import './DisplayResultSN.css'
import { Monitor } from 'grommet-icons';

class DisplayResultSN extends Component {

    constructor(props){
        super(props);
    }

    render() {
    return (
        <div className="result">
            <Monitor color='plain' size='large' /> 
            <h2>{this.props.title}</h2>
            <p>{this.props.result}</p>
        </div>
    );
    }
    }

export default DisplayResultSN;