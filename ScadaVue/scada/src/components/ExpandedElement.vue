<template>
  <v-flex>
    <v-row>
      <v-col cols="6" class="d-flex flex-column">
        <v-card class="mt-6 mb-1 ml-2 mr-1 fill-height">
          <v-card-title class="text-h5 mt-2 ml-2">CO2 & Flaming Details</v-card-title>
          <v-divider class="mx-5 my-1"></v-divider>
          <v-card-text>
            <v-row justify="center">
              <v-chip
                class="ma-2 rounded-pill white--text"
                :color="getFlagChipColor(3, 'CO2FL', 'bypass')"
                label
              >
                <v-icon start class="mx-2">flag</v-icon>
                Bypass
              </v-chip>
            </v-row>
            <v-row :cols="12" justify="center"><p class="text-h7 pa-0 ma-0" >Flaming Process</p></v-row>
            <v-row justify="center">
              <v-chip
                class="ma-2 rounded-pill white--text"
                :color="getFlagChipColor(3, 'R1', 'flag')"
                label
              >
                <v-icon start class="mx-2">flag</v-icon>
                Flaming Robot 1
              </v-chip>
              <v-chip
                class="ma-2 rounded-pill white--text"
                :color="getFlagChipColor(3, 'R2', 'flag')"
                label
              >
                <v-icon start class="mx-2">flag</v-icon>
                Flaming Robot 2
              </v-chip>
            </v-row>
            <v-row :cols="12" justify="center"><p class="text-h7 pa-0 ma-0" >CO2 Process</p></v-row>
            <v-row justify="center">
              <v-chip
                class="ma-2 rounded-pill white--text"
                :color="getFlagChipColor(2, 'R1', 'flag')"
                label
              >
                <v-icon start class="mx-2">flag</v-icon>
                CO2 Robot 1
              </v-chip>
              <v-chip
                class="ma-2 rounded-pill white--text"
                color="info"
                label
              >
                <v-icon start class="mx-2">co2</v-icon>
                Consumption: {{ getValueFromItem(2, 'R1', 'co2xx') }}
              </v-chip>
            </v-row>
            <v-row justify="center">
              <v-chip
                class="ma-2 rounded-pill white--text"
                :color="getFlagChipColor(2, 'R2', 'flag')"
                label
              >
                <v-icon start class="mx-2">flag</v-icon>
                CO2 Robot 2
              </v-chip>
              <v-chip
                class="ma-2 rounded-pill white--text"
                color="info"
                label
              >
                <v-icon start class="mx-2">co2</v-icon>
                Consumption: {{ getValueFromItem(2, 'R2', 'co2xx') }}
              </v-chip>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
      <v-col cols="6" class="d-flex flex-column">
        <v-card class="mt-6 mb-1 ml-1 mr-2 d-flex flex-column fill-height">
          <v-card-title class="text-h5 mt-2 ml-2">Primer Details</v-card-title>
          <v-divider class="mx-5 my-1"></v-divider>
          <v-card-text>
            <v-row justify="center">
              <v-col>
                <v-chip class="ma-2 rounded-pill white--text" :color="getFlagChipColor(4, 'PR', 'bypass')">
                  <v-icon start class="mx-2">flag</v-icon>
                  Bypass
                </v-chip>
                <v-chip class="ma-2 rounded-pill white--text " color="info">
                  <v-icon start class="mx-2">device_thermostat</v-icon>
                  Booth Temperature: {{ getValueFromItem(4, '', 'temperature') }}°
                </v-chip>
                <v-chip class="ma-2 rounded-pill white--text" color="info">
                  <v-icon start class="mx-2">water_drop</v-icon>
                  Booth Humidity:  {{ getValueFromItem(4, '', 'humidity') }}
                </v-chip>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-data-table
                  :headers="PrimerClearDetailsHeaders"                
                  :loading="loading"
                  hide-default-footer
                >
                  <template v-slot:body="{items}">
                    <tbody>
                      <tr v-for="index in 2" :key="index">
                        <td>
                          <v-chip class="ma-2 rounded-pill white--text" :color="getFlagChipColor(4, 'R'+index, 'flag')">
                            <v-icon start class="mx-2">flag</v-icon>
                            Robot {{ index }}
                          </v-chip>
                        </td>
                        <td>{{getValueFromItem(4, 'R'+index, 'resin')}}</td>
                        <td>{{getValueFromItem(4, 'R'+index, 'hardener')}}</td>
                        <td>{{getValueFromItem(4, 'R'+index, 'cleaning')}}</td>
                        <td>{{getValueFromItem(4, 'R'+index, 'colorchg')}}</td>
                      </tr>
                      </tbody>
                  </template>
                </v-data-table>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="6" class="d-flex flex-column">
        <v-card class="mt-1 mb-6 ml-2 mr-1 fill-height">
          <v-card-title class="text-h5 mt-2 ml-2">Basecoat Details</v-card-title>
          <v-divider class="mx-5 my-1"></v-divider>
          <v-card-text>
            <v-row justify="center">
              <v-col>
                <v-chip class="ma-2 rounded-pill white--text" :color="getFlagChipColor(5, 'BC', 'bypass')">
                  <v-icon start class="mx-2">flag</v-icon>
                  Bypass
                </v-chip>
                <v-chip class="ma-2 rounded-pill white--text " color="info">
                  <v-icon start class="mx-2">device_thermostat</v-icon>
                  Booth Temperature: {{ getValueFromItem(5, '', 'temperature') }}°
                </v-chip>
                <v-chip class="ma-2 rounded-pill white--text" color="info">
                  <v-icon start class="mx-2">water_drop</v-icon>
                  Booth Humidity:  {{ getValueFromItem(5, '', 'humidity') }}
                </v-chip>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-data-table
                  :headers="BaseDetailsHeaders"                
                  :loading="loading"
                  hide-default-footer
                  dense
                >
                  <template v-slot:body="{items}">
                    <tbody>
                      <tr v-for="index in 6" :key="index">
                        <td>
                          <v-chip class="ma-2 rounded-pill white--text" :color="getFlagChipColor(5, 'R'+index, 'flag')">
                            <v-icon start class="mx-2">flag</v-icon>
                            Robot {{ index }}
                          </v-chip>
                        </td>
                        <td>{{getValueFromItem(5, 'R'+index, 'resin')}}</td>
                        <td>{{getValueFromItem(5, 'R'+index, 'cleaning')}}</td>
                        <td>{{getValueFromItem(5, 'R'+index, 'colorchg')}}</td>
                      </tr>
                      </tbody>
                  </template>
                </v-data-table>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
      <v-col cols="6" class="d-flex flex-column">
        <v-card class="mt-1 mb-6 ml-1 mr-2 d-flex flex-column fill-height">
          <v-card-title class="text-h5 mt-2 ml-2">Clearcoat Details</v-card-title>
          <v-divider class="mx-5 my-1"></v-divider>
          <v-card-text>
            <v-row justify="center">
              <v-col>
                <v-chip class="ma-2 rounded-pill white--text" :color="getFlagChipColor(6, 'CC', 'bypass')">
                  <v-icon start class="mx-2">flag</v-icon>
                  Bypass
                </v-chip>
                <v-chip class="ma-2 rounded-pill white--text " color="info">
                  <v-icon start class="mx-2">device_thermostat</v-icon>
                  Booth Temperature: {{ getValueFromItem(6, '', 'temperature') }}°
                </v-chip>
                <v-chip class="ma-2 rounded-pill white--text" color="info">
                  <v-icon start class="mx-2">water_drop</v-icon>
                  Booth Humidity:  {{ getValueFromItem(6, '', 'humidity') }}
                </v-chip>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-data-table
                  :headers="PrimerClearDetailsHeaders"                
                  :loading="loading"
                  hide-default-footer
                  dense
                >
                  <template v-slot:body="{items}">
                    <tbody>
                      <tr v-for="index in 4" :key="index">
                        <td>
                          <v-chip class="ma-2 rounded-pill white--text" :color="getFlagChipColor(6, 'R'+index, 'flag')">
                            <v-icon start class="mx-2">flag</v-icon>
                            Robot {{ index }}
                          </v-chip>
                        </td>
                        <td>{{getValueFromItem(6, 'R'+index, 'resin')}}</td>
                        <td>{{getValueFromItem(6, 'R'+index, 'hardener')}}</td>
                        <td>{{getValueFromItem(6, 'R'+index, 'cleaning')}}</td>
                        <td>{{getValueFromItem(6, 'R'+index, 'colorchg')}}</td>
                      </tr>
                      </tbody>
                  </template>
                </v-data-table>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-flex>
</template>
<script>
import axios from 'axios'

export default {
  props: ['itemExpandedLabelID'],
  data() {
    return {
      BaseDetailsHeaders: [
        {text: '', sortable: false},
        {text: 'Resin', sortable: false},
        {text: 'Cleaning', sortable: false},
        {text: 'Color Change', sortable: false},
      ],
      PrimerClearDetailsHeaders: [
        {text: '', sortable: false},
        {text: 'Resin', sortable: false},
        {text: 'Hardener', sortable: false},
        {text: 'Cleaning', sortable: false},
        {text: 'Color Change', sortable: false},
      ],
      loading: false,
      SkidDetails: [],
    }
  },
  methods: {
    loadSkidDetails(LabelID) {
      this.loading = true;
      const url = `Skidprotocols/GetSkidDetails/${LabelID}`; // Construir la URL con el labelID
      axios.get(url)
        .then(response => {
          this.SkidDetails = response.data;
        })
        .catch(error => {
          console.error(error);
        })
        .finally(() => {
          this.loading = false;
        }
        );
    },
    getValueFromItem(position, robotnumber, variable) {
      const element = this.SkidDetails.find(item => item.position === position);
      if (element) {
        let header;
        switch (variable) {
          case 'flag': 
            header = 'flag';
            break;
          case 'resin': 
            header = 'resin';
            break;
          case 'hardener': 
            header = 'hardener';
            break;
          case 'cleaning': 
            header = 'cleaning_';
            break;
          case 'colorchg': 
            header = 'colorChg_';
            break;
          case 'co2xx': 
            header = 'cO2_';
            break;
          case 'bypass': 
            header = 'bypassOnlChg';
            break;
          case 'temperature': 
            header = 'tempBooth';
            break;
          case 'humidity': 
            header = 'humBoothCC';
            break;
        }
        header = header + robotnumber;
        switch(element[header]){
            case true: return true;
            case false: return false;
            case null: return 'Not Used';
            case 0: return 'Not Used';
            default: return element[header];
        }
      }
      else{
        return 'N/A';
      }
    },
    getFlagChipColor(position, robotnumber, variable){
      var flagValue = this.getValueFromItem(position, robotnumber, variable);
      switch (flagValue) {
        case true: return 'success';
        case false: return 'warning';
        default: return 'noinfo';
      }
    },
  },
  watch:{
    itemExpandedLabelID: function(newLabelID){this.loadSkidDetails(newLabelID);}
  },
  mounted() {
    this.loadSkidDetails(this.itemExpandedLabelID);
  }
}
</script>
