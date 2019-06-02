import React, {Component} from 'react';
import ReactPlayer from 'react-player'
import './Video.css'
class Video extends Component {

    render() {
    return (
        <div className="video">
            <ReactPlayer height="500px" width="800px" url='https://www.youtube.com/watch?v=RkNf-QTUzGY' playing />
        </div>
    );
    };
}

export default Video;
