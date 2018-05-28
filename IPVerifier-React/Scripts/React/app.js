import React from "react";
import ReactDOM from "react-dom";
import { compose, withProps } from "recompose";
import {
    withScriptjs,
    withGoogleMap,
    GoogleMap,
    Marker
} from "react-google-maps";

class MapComponent extends react.Component {
    constructor(props) {
        super(props);

        this.state = {
            lat: defaultLat,
            lng: defaultLng
        }; // add fields here you need from state which is set in componentDidMount()
    }
    
    componentDidMount() {
        fetch('https://api.apility.net/geoip/9.9.9.9?token=4c3af26b-44a7-41ee-8505-6b2a9b7e81b8')
        .then(res => {
            this.setState({ data: res.data })}) // setState to the returned json data from api call above
            .catch(err => console.err(err));
    }

    render() {
        return (
            <GoogleMap defaultZoom={10} defaultCenter={{ lat: this.state.defaultLat, lng: this.state.defaultLng }}>
                <Marker position={{ lat: this.state.defaultLat, lng: this.state.defaultLng }} />
            </GoogleMap>
        );
    }
}

//ReactDOM.render(<MapComponent />, document.getElementById("root"));

const MyMapComponent = compose(
    withProps({
        googleMapURL:
        "https://maps.googleapis.com/maps/api/js?key=AIzaSyCY86Q1_a7yhfX-yWBxsi_rgkKtTsELUGk&v=3.exp&libraries=geometry,drawing,places",
        loadingElement: <div style={{ height: `100%` }} />,
        containerElement: <div style={{ height: `400px` }} />,
        mapElement: <div style={{ height: `100%` }} />
    }),
    withScriptjs,
    withGoogleMap
)(props => (
    <GoogleMap defaultZoom={10} defaultCenter={{ lat: 48.8582, lng: 2.3387000000000002 }}>
        {props.isMarkerShown && (
            <Marker position={{ lat: 48.8582, lng: 2.3387000000000002 }} />
        )}
    </GoogleMap>
));

ReactDOM.render(<MyMapComponent isMarkerShown />, document.getElementById("root"));