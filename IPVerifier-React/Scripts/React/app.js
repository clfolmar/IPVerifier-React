import React from "react";
import ReactDOM from "react-dom";
import { compose, withProps } from "recompose";
import {
    withScriptjs,
    withGoogleMap,
    GoogleMap,
    Marker
} from "react-google-maps";

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


