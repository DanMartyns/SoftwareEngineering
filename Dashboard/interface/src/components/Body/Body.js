import React, {Component} from 'react';
import DisplayResultID from '../DisplayResultID/';
import DisplayResultSN from '../DisplayResultSN/';
import DisplayResultDT from '../DisplayResultDT/';
import DisplayResultHR from '../DisplayResultHR/';
import Video from '../Video/';
import './Body.css'
class Body extends Component {

  render() {
    return (
      <body>    
        <h1>Results of an ECG in reaction to a video</h1>
        <div class="split left">
          <div class="centered">
            <Video />            
          </div>
        </div>

        <div class="split right">
          <div class="centered">
            <div className="linha">
              <DisplayResultID title="ID" result ="1"/>
              <DisplayResultSN title="Sensor's Name" result ="1L101"/>  
            </div>
            <div className="linha">
              <DisplayResultHR title="Heart Rate" result ="110"/>
              <DisplayResultDT title="ECG Data Type" result ="VJ_ECG"/>
            </div> 
          </div>
        </div>
      </body>
    );
  }
}

export default Body;
