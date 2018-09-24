import React, { Component } from "react";
import "../Styles/Page.css"
import axios from "axios"
import {BASE_URL} from "../constants"

export default class Page extends Component{
    constructor(props){
        super(props);
        this.state = {
            pageId: this.props.pageId,
            url: this.props.url,
            stopped: this.props.stopped    
        };
    }

    handleStopChecking = () => {
        axios.delete(BASE_URL + "/page/StopChecking?pageId=" + this.props.pageId)
        .then((response) => { 
            console.log(response);
            this.setState({stopped: true});
        }, (error) => {
            console.log(error);
            if(error.response.status === 401){
                this.props.history.push("/unauthorized");
            }
        }
        )
    }

    handleStartChecking = () => {
        axios.get(BASE_URL + "/page/StartChecking?pageId=" + this.props.pageId)
        .then((response) => { 
            console.log(response);
            this.setState({stopped: false});
        }, (error) => {
            console.log(error);
            if(error.response.status === 401){
                this.props.history.push("/unauthorized");
            }
        }
        )
    }

    render(){

        const Changed = (
            <React.Fragment>
                <h6 className="changed-text">Changed</h6>
            </React.Fragment>);

        const NotChanged = (
            <React.Fragment>
                <h6>Not Changed</h6>
            </React.Fragment>)

        const StopButton = (
            <React.Fragment>
                <button className="btn btn-danger float-right" onClick={this.handleStopChecking}>Stop</button>
            </React.Fragment>)

        const StartButton = (
            <React.Fragment>
                <button className="btn btn-success float-right" onClick={this.handleStartChecking}>Start</button>
            </React.Fragment>)

        return (
            <div className="page">
                <div className="row">
                    <div className="col-lg-5 wrap">
                        <h6><a href={this.props.url} target="_blank">{this.props.url}</a></h6>
                    </div>
                    <div className="col-lg-3">
                        <span>Refresh rate: </span><time>{this.props.refreshRate}</time>
                    </div>
                    <div className="col-lg-2">
                        {this.props.hasChanged ? Changed : NotChanged}
                    </div>
                    <div className="col-lg-2">
                        {this.state.stopped ? StartButton : StopButton}
                        <button className="btn btn-danger float-right" onClick={() => this.props.onDelete(this.props.pageId)}>Delete</button>
                    </div>
                </div>
            </div>
        )
    }

}