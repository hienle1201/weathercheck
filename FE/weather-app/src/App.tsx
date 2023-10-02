import React, { FC, useState } from 'react';
import { Card, Col, Form, Input, Row, Space } from 'antd';
import './App.css';
import { fetchZipCode } from './Api/api';
import { WeatherInfo } from './Types/types';

const { Search } = Input;

const App: FC = () => {
  const [weatherInfo, setWeatherInfo] = useState({} as WeatherInfo);
  const onSearch = async (value: string) => {
    const response = await fetchZipCode(value);
    if (response?.data) {
      setWeatherInfo(response.data as WeatherInfo);
    }
  };
  return (
    <div className="App">
      <Space direction="vertical" size="middle" style={{ display: 'flex' }}>
        <Card title="Weather information" size="small">
          <Search placeholder="Please enter zip code. Example: 30076" onSearch={onSearch} style={{ width: 350 }} />
        </Card>
        {weatherInfo?.current ? (
          <Row>
            <Col span={6} offset={6} style={{ padding: 5}}>
              <Card title="Location information" size="small">
                <Form labelCol={{ span: 10 }} wrapperCol={{ span: 20 }} layout="horizontal" style={{ maxWidth: 600 }}>
                  <Form.Item label="Country">
                    <label>{weatherInfo?.location?.country}</label>
                  </Form.Item>
                  <Form.Item label="Location">
                    <label>{weatherInfo?.location?.name}</label>
                  </Form.Item>
                  <Form.Item label="Weather descriptions">
                    <label>{weatherInfo?.current?.weather_descriptions?.join(', ')}</label>
                  </Form.Item>
                  <Form.Item label="Wind speed">
                    <label>{weatherInfo?.current?.wind_speed}</label>
                  </Form.Item>
                  <Form.Item label="UV Index">
                    <label>{weatherInfo?.current?.uv_index}</label>
                  </Form.Item>
                </Form>
              </Card>
            </Col>
            <Col span={6} style={{ padding: 5}}>
              <Card title="Suggestion" size="small">
                <Form labelCol={{ span: 10 }} wrapperCol={{ span: 20 }} layout="horizontal" style={{ maxWidth: 600, textAlign: 'left' }}>
                    <ul>
                      <li>
                        {weatherInfo.current.weather_descriptions?.join()?.toLocaleLowerCase()?.includes("rain") ? ("It's rain. You should stay in home") : ("It's not rain. You should go outside")}
                      </li>
                      <li>
                        {(weatherInfo.current.uv_index ?? 0) > 3  ? ("UV index is hight. You should wear sunscreen") : ("UV index is low. You do not need wear sunscreen")}
                      </li> 
                      <li>
                        {(!weatherInfo.current.weather_descriptions?.join()?.toLocaleLowerCase()?.includes("rain")) && (weatherInfo.current.wind_speed ?? 0) > 15  ? ("You can fly your kite") : ("weather is bad. You can not fly your kite")}
                      </li> 
                    </ul>
                </Form>
              </Card>
            </Col>
          </Row>
        ) : null}
      </Space>
    </div>
  );
};

export default App;
