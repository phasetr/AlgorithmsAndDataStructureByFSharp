USER root

RUN apt update && \
    apt -y install jupyter-notebook ruby ruby-ffi-rzmq && \
    gem install iruby && \
    iruby register --force

# RUN julia -e 'using Pkg; Pkg.add("Plots"); using Plots'
# RUN julia -e 'using Pkg; Pkg.add("DifferentialEquations"); using DifferentialEquations'

ENV LANG ja_JP.UTF-8
ENV LANGUAGE ja_JP:ja
ENV LC_ALL ja_JP.UTF-8
ENV TZ JST-9

#CMD ["jupyter-notebook", "--port=8000", "--ip=0.0.0.0", "--allow-root", "--NotebookApp.token=''"]
