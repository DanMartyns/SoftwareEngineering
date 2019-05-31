import React, {Component} from 'react';
import DisplayResultID from '../DisplayResultID/';
import DisplayResultSN from '../DisplayResultSN/';
import DisplayResultDT from '../DisplayResultDT/';
import DisplayResultHR from '../DisplayResultHR/';
import Video from '../Video/';
import './Body.css'
class Body extends Component {

  constructor(props) {
    super(props);
    this.state = {
      items: [],
      isLoaded: false,
    }
  }

  componentDidMount() {
    fetch('http://172.16.238.20:42020/')
      .then(res => res.json())
      .then(json => {
        this.setState({
          isLoaded: true,
          items: json,
        })
      })
      .catch(function(error) {
        console.log('Looks like there was a problem: \n', error);
      });
  }  
  render() {
    var { isLoaded, items } = this.state;
    console.log(isLoaded);
    console.log(items);
    if(!isLoaded) {
      return <div><h1>Loading...</h1></div>
    }
    else {
      return (
        <body>    
          <h1>Results of an ECG in reaction to a video</h1>
          <div className="split left">
            <div className="centered">
              <Video />            
            </div>
          </div>

          <div className="split right">
            <div className="centered">
              <div className="linha">
                <DisplayResultSN title="Sensor's Name" result = {items.sensor_name} />  
              </div>
              <div className="linha">
                <DisplayResultHR title="Heart Rate" result ="110"/>
                <DisplayResultDT title="ECG Data Type" result ={items.current_value_bpm}/>
              </div> 
            </div>
          </div>
        </body>
      );
    }
  }
}

export default Body;
