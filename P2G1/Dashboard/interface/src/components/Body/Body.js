import React, {Component} from 'react';
import DisplayResultSN from '../DisplayResultSN/';
import DisplayResultHR from '../DisplayResultHR/';
import Video from '../Video/';
import './Body.css';


class Body extends Component {

  constructor(props) {
    super(props);
    this.state = {
      items: [],
      isLoaded: false
    }
  }

  componentDidMount() {
    this.getValues();
    this.interval = setInterval(() => {
      this.getValues();
    }, 1000);
        
  }
  
  getValues() {
    fetch('http://172.16.238.30:8080/data', {headers: {"Access-Control-Allow-Origin": "*", "Access-Control-Allow-Headers": "content-type, Authorization", "Access-Control-Allow-Methods": "GET,HEAD,POST,PUT,PATCH,DELETE,OPTIONS,TRACE"}})
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

  componentWillUnmount() {
    clearInterval(this.interval);
  }
  
  render() {
    var { isLoaded, items } = this.state;
    console.log("IsLoaded :",isLoaded);
    console.log("Items : ",items);
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
                <DisplayResultSN title="Sensor's Name" result = {items.sensor_name}/>  
                <DisplayResultHR title="Current Heartrate" result ={items.current_value}/>
              </div>                
            </div>
          </div>
        </body>
      );
    }
  }
}

export default Body;
