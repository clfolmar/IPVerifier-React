import React from "react";
import ReactDOM from "react-dom";
import { compose, withProps } from "recompose";
import {
    withScriptjs,
    withGoogleMap,
    GoogleMap,
    Marker
} from "react-google-maps";
import { GoogleApiWrapper } from 'google-maps-react';


//const MyMapComponent = compose(
//    withProps({
//        googleMapURL:
//        "https://maps.googleapis.com/maps/api/js?key=AIzaSyCY86Q1_a7yhfX-yWBxsi_rgkKtTsELUGk&v=3.exp&libraries=geometry,drawing,places",
//        loadingElement: <div style={{ height: `100%` }} />,
//        containerElement: <div style={{ height: `400px` }} />,
//        mapElement: <div style={{ height: `100%` }} />
//    }),
//    withScriptjs,
//    withGoogleMap
//)(props => (
//    <GoogleMap defaultZoom={10} defaultCenter={{ lat: 48.8582, lng: 2.3387000000000002 }}>
//        {props.isMarkerShown && (
//            <Marker position={{ lat: 48.8582, lng: 2.3387000000000002 }} />
//        )}
//    </GoogleMap>
//));

class Container extends React.Component {
    render() {
        const style = {
            width: '100vw',
            height: '80vh'
        }
        if (!this.props.loaded) {
            return <div>Loading...</div>
        }
        return (
            <div style={style}>
                <span>testing</span>
                <Map google={this.props.google} />
            </div>
        )
    }
}

class FolmarMap extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            lat: defaultLat,
            lng: defaultLng
        };
    }

    componentDidMount() {
        fetch('https://api.apility.net/geoip/9.9.9.9?token=4c3af26b-44a7-41ee-8505-6b2a9b7e81b8')
            .then(res => {
                this.setState({ data: res.data })
            }) // setState to the returned json data from api call above
            .catch(err => console.err(err));
    }

    render() {
        return <GoogleMap defaultZoom={10} defaultCenter={{ lat: this.state.defaultLat, lng: this.state.defaultLng }} />
    }
}

class Map extends React.Component {
    componentDidUpdate(prevProps, prevState) {
        if (prevProps.google !== this.props.google) {
            this.loadMap();
        }
    }

    componentDidMount() {
        this.loadMap();
    }

    loadMap() {
        if (this.props && this.props.google) {
            // google is available
            const { google } = this.props;
            const maps = google.maps;

            const mapRef = this.refs.map;
            const node = ReactDOM.findDOMNode(mapRef);

            let zoom = 14;
            let lat = 37.774929;
            let lng = -122.419416;
            const center = new maps.LatLng(lat, lng);
            const mapConfig = Object.assign({}, {
                center: center,
                zoom: zoom
            })
            this.map = new maps.Map(node, mapConfig);
        }
    }

    render() {
        return (
            <div ref='map'>
                Loading map...
      </div>
        )
    }
}

ReactDOM.render(<FolmarMap />, document.getElementById("root"));

//GoogleApiWrapper({
//    apiKey: 'AIzaSyCY86Q1_a7yhfX-yWBxsi_rgkKtTsELUGk'
//})(Container)
